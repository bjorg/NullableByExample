﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace NullableByExample {

    public class Solution_Methods {

        //--- Class Methods ---
        public static void Example() {

            // Exercise 1: fetch a record using a known ID
            var record1 = Fetch("123");
            Store(record1);
            Console.WriteLine(record1.Id);

            // Exercise 2: fetch a record using user input and validation
            var record2 = Fetch(GetId());
            if(IsValid(record2)) {
                Store(record2);
                Console.WriteLine(record2.Id);
            }

            // Exercise 3: fetch a record using user input and assertion
            var record3 = Fetch(GetId());
            AssertNotNull(record3);
            Store(record3);
            Console.WriteLine(record3.Id);

            // Exercise 4: try-fetch a record
            if(TryFetch("123", out var record4)) {
                Store(record4);
                Console.WriteLine(record4.Id);
            }

            // Exercise 5: fetch and don't validate
            var record5 = Fetch(GetId());
            Store(record5!);
            Console.WriteLine(record5!.Id);
        }

        /// <summary>
        /// The <see cref="GetId()" method returns the user input from the
        /// command line or <c>null</c> when the user provided no input.
        /// </summary>
        /// <returns>User input or <c>null</c>.</returns>
        public static string? GetId() {
            var input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? null : input.Trim();
        }

        /// <summary>
        /// The <see cref="Fetch(string)"/> method fetches a record. This method
        /// throws an exception if the record was not found or returns <c>null</c>
        /// when <paramref name="id"/> is <c>null</c>.
        /// </summary>
        /// <param name="id">The ID of the record to fetch.</param>
        /// <returns>A <see cref="Record"/> instance or <c>null</c> when <paramref name="id"/> is <c>null</c>.</returns>
        [return: NotNullIfNotNull("id")]
        public static Record? Fetch(string? id) => (id == null)
            ? null
            : new Record {
                Id = id
            };

        /// <summary>
        /// The <see cref="TryFetch(string,out Record)"/> method attempts to fetch
        /// a record and returns <c>true</c> on success.
        /// </summary>
        /// <param name="id">The ID of the record to fetch.</param>
        /// <param name="record">The fetched <see cref="Record"/> on success, <c>null</c> otherwise.</param>
        /// <returns><c>true</c> on success, otherwise <c>false</c>.</returns>
        public static bool TryFetch(string? id, [NotNullWhen(true)] out Record? record) {
            record = (id == null)
                ? null
                : new Record {
                    Id = id
                };
            return record != null;
        }

        /// <summary>
        /// The <see cref="Store(Record)"/> method stores a record.
        /// </summary>
        /// <param name="record">The <see cref="Record"/> to store.</param>
        public static void Store(Record record) {
            if(record == null) {
                throw new ArgumentNullException(nameof(record));
            }
        }

        /// <summary>
        /// The <see cref="IsValid(Record)"/> method checks if a <see cref="Record"/>
        /// instance is valid;
        /// </summary>
        /// <param name="record">The <see cref="Record"/> to validate.</param>
        /// <returns><c>true</c> when valid, otherwise <c>false</c>.</returns>
        public static bool IsValid([NotNullWhen(true)] Record? record) => record != null;

        /// <summary>
        /// The <see cref="AssertNotNull(Record)"/> method validates a <see cref="Record"/>
        /// instance. If the instance is not valid, an exception is raised.
        /// </summary>
        /// <param name="record">The <see cref="Record"/> to validate.</param>
        public static void AssertNotNull([NotNull] Record? record) {
            if(record == null) {
                throw new ApplicationException();
            }
        }
    }
}
