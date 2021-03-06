﻿namespace Exercise
{
    public abstract class Item : LibObject
    {
        public Item(int amount, int year)
        {
            AvailableAmount = amount;
            ObjType = ObjectType.Item;
            YearCreated = year;
        }
    }

    public class Book : Item
    {
        public Book(string author, string title, int year, int amount) : base(amount, year)
        {
            NameOrTitle = title;
            Author = author;
        }
        public string Author { get; set; }

        public virtual void BorrowOne() { }    
    }

    public class BookRegistration : IRegistarable
    {
        private readonly Book _book;

        public BookRegistration(Book book)
        {
            _book = book;
        }

        public RegisteredObject GetRegistrationInfo()
        {
            return new RegisteredObject()
            {
                AvailableAmount = _book.AvailableAmount,
                Id = _book.ObjectId,
                Info = _book.NameOrTitle
            };
        }
    }
}
