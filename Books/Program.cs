// See https://aka.ms/new-console-template for more information
using Books.Repositories;
using Books.UserInterface;

// Array instead of db 
var inMemoryRepository = new BookRepositoryInMemory();
var app = new MenuHandler(inMemoryRepository);

app.Start();