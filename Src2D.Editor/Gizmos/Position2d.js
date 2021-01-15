var startPosition;

return [
    {
        UseRotation: false,
        Color: Colors.Red,
        HoverColor: Colors.DarkRed,
        DragColor: Colors.Black,
        Shape: [
            Point(-5, -5),
            Point(-100, -5),
            Point(-100, -15),
            Point(-110, 0),
            Point(-100, 15),
            Point(-100, 5),
            Point(-5, 5)
        ],
        StartDrag: () => {
            startPosition = entity.Position;
        },
        Drag: (direction) => {
            var newX = direction.X + entity.Position.X;
            entity.Position = Vector2(newX, entity.Position.Y);
        },
        EndDrag: () => {
            var oldPosition = startPosition;
            var newPosition = entity.Position;
            DoAction(() => { entity.Position = newPosition; }, () => { entity.Position = oldPosition; });
        }
    },
    {
        UseRotation: false,
        Color: Colors.Blue,
        HoverColor: Colors.DarkBlue,
        DragColor: Colors.Black,
        Shape: [
            Point(-5, -5),
            Point(-5, -100),
            Point(-15, -100),
            Point(0, -110),
            Point(15, -100),
            Point(5, -100),
            Point(5, -5)
        ],
        StartDrag: () => {
            startPosition = entity.Position;
        },
        Drag: (direction) => {
            var newY = direction.Y + entity.Position.Y;
            entity.Position = Vector2(entity.Position.X, newY);
        },
        EndDrag: () => {
            var oldPosition = startPosition;
            var newPosition = entity.Position;
            DoAction(() => { entity.Position = newPosition; }, () => { entity.Position = oldPosition; });
        }
    },
    {
        UseRotation: false,
        Color: Colors.Green,
        HoverColor: Colors.DarkGreen,
        DragColor: Colors.Black,
        Shape: [
            Point(-5, -5),
            Point(-5, 5),
            Point(5, 5),
            Point(5, -5)
        ],
        StartDrag: () => {
            startPosition = entity.Position;
        },
        Drag: (direction) => {
            var newX = direction.X + entity.Position.X;
            var newY = direction.Y + entity.Position.Y;
            entity.Position = Vector2(newX, newY);
        },
        EndDrag: () => {
            var oldPosition = startPosition;
            var newPosition = entity.Position;
            DoAction(() => { entity.Position = newPosition; }, () => { entity.Position = oldPosition; });
        }
    }
]