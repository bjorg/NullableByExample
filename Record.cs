using System;

namespace NullableByExample {

    public class Record {

        //--- Fields ---
        private string? _id;

        //--- Properties ---
        public string Id {
            get => _id ?? throw new InvalidOperationException();
            set => _id = value ?? throw new ArgumentNullException();
        }
    }
}
