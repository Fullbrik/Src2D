var start;

return [
    {
        Color: Colors.White,
        HoverColor: Colors.LightGrey,
        DragColor: Colors.Grey,
        Shape: [
            Point(-5, -5),
            Point(-5, 5),
            Point(5, 5),
            Point(5, -5)
        ],
        StartDrag: () => {
            start = entity.GetProperty("Property");
        },
        Drag: (direction) => {
            var newX = direction.X;
            entity.SetProperty("Property", newX);
        },
        EndDrag: () => {
            var old = start;
            var newX = entity.GetProperty("Property");
            DoAction(
                () => { entity.SetProperty("Property", newX); },
                () => { entity.SetProperty("Property", old); }
            );
        }
    }
]