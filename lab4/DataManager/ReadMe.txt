1) DataManager с помощью ConfigurationManager получает настройки Configuration из XML/JSON файла.
2) DataManager используя ServiceLayer и DataAccessLayer получает List<Person> из пяти таблиц базы данных.
3) DataManager формирует XML файл из списка людей.
4) DataManager отправляет этот файл на ftpserver для дальнейшего использование ETL-службой, которая реализована в отдельном проекте https://github.com/danymalets/csharp/tree/master/ETL
