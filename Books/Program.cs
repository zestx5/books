// See https://aka.ms/new-console-template for more information
using Books.Models;
using Books.Repositories;
using Books.UserInterface;

// Array instead of db 
var inMemoryRepository = new BookRepositoryInMemory();

// 'db seed'
var testBook = new Book("Author", "Title", "Gengre", Books.Enums.BookStatus.Read);
inMemoryRepository.Add(testBook);

var app = new MenuHandler(inMemoryRepository);

app.Start();