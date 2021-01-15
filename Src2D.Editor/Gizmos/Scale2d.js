var startScale;

return [
    {
        UseRotation: true,
        Color: Colors.Red,
        HoverColor: Colors.DarkRed,
        DragColor: Colors.Black,
        Shape: [
            Point(5, -5),
            Point(100, -5),
            Point(100, -10),
            Point(115, -10),
            Point(115, 10),
            Point(100, 10),
            Point(100, 5),
            Point(5, 5)
        ],
        StartDrag: () => {
            startScale = entity.Scale;
        },
        Drag: (direction) => {
            var newX = direction.X * 0.01 + entity.Scale.X;
            entity.Scale = Vector2(newX, entity.Scale.Y);
        },
        EndDrag: () => {
            var oldScale = startScale;
            var newScale = entity.Scale;
            DoAction(() => { entity.Scale = newScale; }, () => { entity.Scale = oldScale; });
        }
    },
    {
        UseRotation: true,
        Color: Colors.Blue,
        HoverColor: Colors.DarkBlue,
        DragColor: Colors.Black,
        Shape: [
            Point(-5, -5),
            Point(-5, -100),
            Point(-10, -100),
            Point(-10, -115),
            Point(10, -115),
            Point(10, -100),
            Point(5, -100),
            Point(5, -5)
        ],
        StartDrag: () => {
            startScale = entity.Scale;
        },
        Drag: (direction) => {
            var newY = direction.Y * -0.01 + entity.Scale.Y;
            entity.Scale = Vector2(entity.Scale.X, newY);
        },
        EndDrag: () => {
            var oldScale = startScale;
            var newScale = entity.Scale;
            DoAction(() => { entity.Scale = newScale; }, () => { entity.Scale = oldScale; });
        }
    },
    {
        UseRotation: true,
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
            startScale = entity.Scale;
        },
        Drag: (direction) => {
            var newX = direction.X * .01;
            var newY = direction.Y * .01;

            var newBoth = (newX + newY) * 0.5;

            var normScal = Vector2(entity.Scale.X, entity.Scale.Y);
            normScal.Normalize();

            if(normScal.X < 0) normScal.X = normScal.X * -1.0;
            if(normScal.Y < 0) normScal.Y = normScal.Y * -1.0;

            entity.Scale = Vector2(newBoth * normScal.X + entity.Scale.X, newBoth * normScal.Y + entity.Scale.Y);
        },
        EndDrag: () => {
            var oldScale = startScale;
            var newScale = entity.Scale;
            DoAction(() => { entity.Scale = newScale; }, () => { entity.Scale = oldScale; });
        }
    }
]