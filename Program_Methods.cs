using System;
using System.Diagnostics.CodeAnalysis;

namespace NullableByExample {

    public partial class Program {

        //--- Class Methods ---
        public static string? GetId() {
            var input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? null : input.Trim();
        }

        public static void Store(Record record) { /* ... */ }

        [return: NotNullIfNotNull("id") ]
        public static Record? Fetch(string? id) {
            if(id == null) {
                return null;
            }
            return new Record {
                Id = id
            };
        }

        public static bool TryFetch(string? id, [NotNullWhen(true)] out Record? record) {
            if(id == null) {
                record = null;
                return false;
            }
            record = new Record {
                Id = id
            };
            return true;
        }


        public static bool IsValid([NotNullWhen(true)] Record? record) => record != null;

        public static void AssertNotNull([NotNull] Record? record) {
            if(record == null) {
                throw new ApplicationException();
            }
        }

        [return: MaybeNull]
        public static T FindOrDefault<T>(string? id) => default;
    }
}
