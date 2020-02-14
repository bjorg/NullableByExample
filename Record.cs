using System;
using System.Diagnostics.CodeAnalysis;

namespace NullableByExample {

    public class Record {

        //--- Fields ---
        private string? _id;
        private string? _owner;
        private string? _data;

        //--- Properties ---
        public string Id {
            get => _id ?? throw new InvalidOperationException();
            set => _id = value ?? throw new ArgumentNullException();
        }

        // returned property value is never null, but can be set to null
        [AllowNull]
        public string Owner {
            get => _owner ?? "<default>";
            set => _owner = value;
        }

        // property value could be null at first, but can never be set to null
        [DisallowNull]
        public string? Data {
            get => _data;
            set => _data = value ?? throw new ArgumentNullException();
        }
    }
}
