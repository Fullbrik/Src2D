using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Src2D.Editor.Previews.MapEditor;
using Src2D.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Src2D.Editor.Gizmos
{
    public class ScriptGizmo : Gizmo
    {
        private readonly Func<string> loadScript;

        private readonly V8ScriptEngine engine;
        private readonly GraphicsDevice graphicsDevice;

        public ScriptGizmo(MapEditorEntity entity, GraphicsDevice graphicsDevice, Func<string> loadScript) : base(entity)
        {
            //Setup values
            this.loadScript = loadScript;
            this.graphicsDevice = graphicsDevice;

            //Create the script engine
            engine = new V8ScriptEngine();

            engine.Execute("var builder = () => []; var Handles = [];");

            //Add host functions
            engine.AddHostObject("host", new HostFunctions());

            //Add in all the types to be exposed in simple functions
            engine.AddHostObject("Point",
                new Func<int, int, Point>((x, y) => { return new Point(x, y); }));
            engine.AddHostObject("Vector2",
                new Func<float, float, Vector2>((x, y) => { return new Vector2(x, y); }));
            engine.AddHostObject("Vector2I",
                new Func<int, int, Vector2>((x, y) => { return new Vector2(x, y); }));
            engine.AddHostObject("Color",
                new Func<byte, byte, byte, byte, Color>((r, g, b, a) => { return new Color(r, g, b, a); }));
            engine.AddHostObject("Colors", new ColorsObject());
            engine.AddHostObject("NGon", new Func<int, int, Point[]>((n, r) =>
            {
                return Shape2D.GenerateNGon(n, r).ToArray();
            }));
            engine.AddHostObject("AngleBetween", new Func<Vector2, Vector2, float>((p1, p2) =>
            {
                return MathHelper.ToDegrees((float)Math.Atan2(p2.Y - p1.Y, p2.X - p1.X));
            }));
            engine.AddHostObject("DoAction",
                new Action<dynamic, dynamic>(
                    (d1, d2) =>
                    entity.Preview.DoAction(() => d1(), () => d2())));
            engine.AddHostObject("Reload", new Action(() => Reload()));
            engine.AddHostObject("entity", entity);

            //Execute helper function
            engine.Execute(@"
    Array.prototype.toClrArray = function () {
        var clrArray = host.newArr(this.length);
        for (var i = 0; i < this.length; ++i) {
            clrArray[i] = this[i];
        }
        return clrArray;
    };
");
        }

        public override void Reload()
        {
            engine.Script.entity = Entity;
            string script = loadScript();
            engine.Execute("builder = () => {" + script + "}\nHandles = builder();");
            LoadHandles();

            base.Reload();
        }

        private void LoadHandles()
        {
            var handles = engine.Script.Handles.toClrArray() as Array;

            Handles.Clear();
            for (int i = 0; i < handles.Length; i++)
            {
                Handles.Add(new ScriptGizmoHandle(handles.GetValue(i), graphicsDevice, engine));
            }
        }
    }

    public class ScriptGizmoHandle : GizmoHandle
    {
        public override Color Color => color;
        private Color color = Color.White;

        public override Color HoverColor => hoverColor;
        private Color hoverColor = Color.LightGray;

        public override Color DragColor => dragColor;

        public override bool UseRotation => useRotation;
        private bool useRotation = true;

        private Color dragColor = Color.Gray;

        private V8ScriptEngine scriptEngine;

        private dynamic shape;
        private dynamic handle;

        private dynamic startDrag, drag, endDrag;

        public ScriptGizmoHandle(
            dynamic handle,
            GraphicsDevice graphicsDevice,
            V8ScriptEngine scriptEngine) : base(graphicsDevice)
        {
            this.handle = handle;
            this.scriptEngine = scriptEngine;
        }

        public override void OnReload()
        {
            useRotation = handle.UseRotation;

            color = handle.Color;
            hoverColor = handle.HoverColor;
            dragColor = handle.DragColor;

            shape = handle.Shape;

            startDrag = handle.StartDrag;
            drag = handle.Drag;
            endDrag = handle.EndDrag;
        }

        public override Point[] BuildShape()
        {
            var arr = shape.toClrArray() as Array;
            return arr.SelectDynamic(p => new Point((int)p.X, (int)p.Y)).ToArray();
        }

        public override void OnStartDrag(Vector2 mousePos)
        {
            startDrag(mousePos);
        }

        public override void OnDrag(Vector2 direction)
        {
            drag(direction);
        }

        public override void OnEndDrag()
        {
            endDrag();
        }
    }
}
