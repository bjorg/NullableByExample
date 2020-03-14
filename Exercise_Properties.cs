// TODO:
//  Remove the #nullable pragma to make the code null-aware.
//  Then annotate the code to remove all compiler warnings.
#nullable disable

using System;
using System.Diagnostics.CodeAnalysis;

namespace NullableByExample {

    // This exercise focuses on annotating properties for various nullable scenarios.
    public class Exercise_Properties {

        //--- Class Methods ---
        public static void Main() {
            var record = new Record {
                Id = "123"
            };

            // Exercise 1: allow the 'Owner' property to be reset to its default behavior
            record.Owner = "Bob";
            record.Owner = null;
            Console.WriteLine($"Owner: {record.Owner}");

            // Exercise 2: warn on attempt to assign 'null' to the 'Data' property.
            record.Data = "456";
            record.Data = null; // <-- this should be a warning
            Console.WriteLine($"Owner: {record.Data ?? "<null>"}");
        }

        //--- Types ---
        public class Record {

            //--- Fields ---
            private string _id;
            private string _owner;
            private string _data;

            //--- Properties ---
            public string Id {
                get => _id ?? throw new InvalidOperationException();
                set => _id = value ?? throw new ArgumentNullException();
            }

            /// <summary>
            /// The <see cref="Owner"/> property returns the name of the record owner
            /// or <c>"<default>"</c> when no owner is set.
            /// </summary>
            /// <value>The name of the owner.</value>
            public string Owner {
                get => _owner ?? "<default>";
                set => _owner = value;
            }

            /// <summary>
            /// The <see cref="Data"/> property returns the data of the record. The
            /// returned value may be <c>null</c> if the record has not been initalized.
            /// </summary>
            /// <value>The data for the record or <c>null</c> when not initialized.</value>
            public string Data {
                get => _data;
                set => _data = value ?? throw new ArgumentNullException();
            }
        }
    }
}
