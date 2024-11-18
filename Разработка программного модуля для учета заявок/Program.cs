var builder = WebApplication.CreateBuilder();
var app = builder.Build();

//Список заявок(База данных)
List<Order> repo = 
[
    new (1, 2, 5, 2013, "Компьютер", "Отвал чипа", "да", "А.М.Антонов", "в ожидании"),
];

//Get- отвечает за получение(допустим "app.MapGet("/", () => repo);" получает информацию из репозитория(repo) и выводит ее на сайте) 
app.MapGet("/", () => repo);

//Post- отвечает за влияние извне(пользователь)
app.MapPost("/", (Order zaiavka) => repo.Add(zaiavka));

//Run- запускает приложение
app.Run();




class Order
{
    int number;
    int day;
    int mouth;
    int year;
    string device;
    string problemType;
    string descriprion;
    string client;
    string status;


    public Order(int number, int day, int mouth, int year, string device, string problemType, string descriprion, string client, string status)
    {
        Number = number;
        Day = day;
        Mouth = mouth;
        Year = year;
        Device = device;
        ProblemType = problemType;
        Descriprion = descriprion;
        Client = client;
        Status = status;
    }

    public int Number {get; set;}
    public int Day {get; set;}
    public int Mouth {get; set;}
    public int Year {get; set;}
    public string Device {get; set;}
    public string ProblemType {get; set;}
    public string Descriprion {get; set;}
    public string Client {get; set;}
    public string Status {get; set;}
}