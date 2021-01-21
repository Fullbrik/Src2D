var mousePos = Vector2(0, 0);
var lastAngle = 0;
var startRotation;

return [
    {
        UseRotation: true,
        Color: Colors.Red,
        HoverColor: Colors.DarkRed,
        DragColor: Colors.Black,
        Shape: [
            ...NGon(20, -70),
        ],
        StartDrag: (mp) => {
            startRotation = entity.Rotation;
            mousePos = mp;
            lastAngle = AngleBetween(Vector2(mousePos.X, mousePos.Y), entity.Position);
        },
        Drag: (direction) => {
            mousePos = Vector2(direction.X + mousePos.X, direction.Y + mousePos.Y);

            var angle = AngleBetween(Vector2I(mousePos.X, mousePos.Y), entity.Position);
            var angleDelta = angle - lastAngle;
            lastAngle = angle;

            entity.Rotation += angleDelta;
        },
        EndDrag: () => {
            var oldRotation = startRotation;
            var newRotation = entity.Rotation;
            DoAction(() => { entity.Rotation = newRotation; }, () => { entity.Rotation = oldRotation; });
        }
    },
    {
        UseRotation: true,
        Color: Colors.Red,
        HoverColor: Colors.Red,
        DragColor: Colors.Red,
        Shape: [
            Point(10, -70),
            Point(0, -80),
            Point(-10, -70),
        ],
        StartDrag: () => {
        },
        Drag: (direction) => {
        },
        EndDrag: () => {
        }
    }
]