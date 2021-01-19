using Src2D.Editor.Previews.MapEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Src2D.Editor.Winforms.Tools.MapEditor
{
    public partial class BindingEditorDialog : Form
    {
        MapEditorEntity entity;
        MapPreviewBinding binding;
        MapEditorPreview preveiw;

        public BindingEditorDialog(MapEditorEntity entity, MapPreviewBinding binding, MapEditorPreview preveiw)
        {
            InitializeComponent();

            this.entity = entity;
            this.binding = binding;
            this.preveiw = preveiw;
        }

        private void BindingEditorDialog_Load(object sender, EventArgs e)
        {
            EventName.Text = binding.EventName;
            EventName.Items.AddRange(entity.Data.Events.Keys.ToArray());

            OtherEntity.Text = binding.OtherEntityName;
            OtherEntity.AutoCompleteCustomSource.AddRange(preveiw.EntityNames);
            OtherEntity.AutoCompleteMode = AutoCompleteMode.Suggest;
            OtherEntity.AutoCompleteSource = AutoCompleteSource.CustomSource;

            ActionName.Text = binding.ActionName;

            OverideParam.Checked = binding.OverrideParam;
            OverideParam_CheckedChanged(OverideParam, EventArgs.Empty);

            ParamOveride.Text = binding.ParamOverride;
        }

        private void EventName_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void OtherEntity_TextChanged(object sender, EventArgs e)
        {
            //ActionName.Items.Clear();
            //ActionName.Items.AddRange(preveiw.Entities
            //    .Where(ent => ent.Name != null && Regex.IsMatch(ent.Name, OtherEntity.Text))
            //    .Select(ent => ent.Data.Actions.Keys)
            //    .Flatten()
            //    .ToArray());
        }

        private void ActionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var options = preveiw.Entities
                .Where(ent => ent.Name != null && Regex.IsMatch(ent.Name, OtherEntity.Text))
                .Select(ent => ent.Data.Actions)
                .Flatten()
                .Where(kvp => kvp.Key == ActionName.Text)
                .Select(kvp => kvp.Value.ParamOptions)
                .Flatten()
                .Distinct()
                .ToArray();

            if(options.Length > 0)
            {
                ParamOveride.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                ParamOveride.AutoCompleteSource = AutoCompleteSource.CustomSource;
                ParamOveride.AutoCompleteCustomSource.Clear();
                ParamOveride.AutoCompleteCustomSource.AddRange(options);
            }
            else
            {
                ParamOveride.AutoCompleteMode = AutoCompleteMode.None;
            }
        }

        private void OverideParam_CheckedChanged(object sender, EventArgs e)
        {
            ParamOveride.ReadOnly = !OverideParam.Checked;
        }

        private void ParamOveride_TextChanged(object sender, EventArgs e)
        {

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            var oldEventName = binding.EventName;
            var oldOtherEntity = binding.OtherEntityName;
            var oldActionName = binding.ActionName;
            var oldOverideParam = binding.OverrideParam;
            var oldParamOveride = binding.ParamOverride;

            preveiw.DoAction(() =>
            {
                binding.EventName = EventName.Text;
                binding.OtherEntityName = OtherEntity.Text;
                binding.ActionName = ActionName.Text;
                binding.OverrideParam = OverideParam.Checked;
                binding.ParamOverride =
                    (OverideParam.Checked) ? ParamOveride.Text : "";
            },
            () =>
            {
                binding.EventName = oldEventName;
                binding.OtherEntityName = oldOtherEntity;
                binding.ActionName = oldActionName;
                binding.OverrideParam = oldOverideParam;
                binding.ParamOverride = oldParamOveride;
            });

            DialogResult = DialogResult.OK;
        }

        private void ActionName_Enter(object sender, EventArgs e)
        {
            ActionName.Items.Clear();
            ActionName.Items.AddRange(preveiw.Entities
                .Where(ent => ent.Name != null && Regex.IsMatch(ent.Name, OtherEntity.Text))
                .Select(ent => ent.Data.Actions.Keys)
                .Flatten()
                .ToArray());
        }
    }
}
