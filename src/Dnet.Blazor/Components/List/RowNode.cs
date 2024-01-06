﻿namespace Dnet.Blazor.Components.List
{
    public class RowNode<TItem>
    {
        private bool _selected { get; set; }

        public bool Show { get; set; }

        public long RowNodeId { get; set; }

        public TItem RowData { get; set; }

        public bool Selectable { get; set; } = true;

        public bool Selected
        {
            get => _selected;
            set
            {
                if (!Selectable || _selected == value)
                    return;
                _selected = value;
            }
        }
    }
}
