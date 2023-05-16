using System;
using System.Linq;

BloggingContext db = new BloggingContext();

var crud = new Crud(db);

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

crud.Create();
crud.Read();
crud.Update();
crud.Read();
//crud.Delete();