var builder = WebApplication.CreateBuilder();
var app = builder.Build();

//Список заявок(База данных)
List<Order> repo = 
[
    new (1, 2, 5, 2013, "Компьютер", "Отвал чипа", "да", "А.М.Антонов", "в ожидании", "Олег"),
];

//Get- отвечает за получение(допустим "app.MapGet("/", () => repo);" получает информацию из репозитория(repo) и выводит ее на сайте) 
app.MapGet("/", () => repo);

//Post- отвечает за влияние извне(пользователь)
app.MapPost("/", (Order zaiavka) => repo.Add(zaiavka));

//Put- отвечает
app.MapPut("/{number}", (int number, OrderUpdateDTO dto) => //Приходит объект OrderUpdateDTO
{
    Order buffer = repo.Find(x => x.Number == number); // Номер заявки 
    if (buffer == null) 
        return Results.NotFound("...");
    buffer.Status = dto.Status;
    buffer.Master = dto.Master;
    buffer.Description = dto.Description;
    return Results.Json(buffer);
});
//Run- запускает приложение
app.Run();

//DTO- передает в MapPut 3 поля: 
record class OrderUpdateDTO(string Status, string Description, string Master);


class Order
{
    int number;
    int day;
    int mouth;
    int year;
    string device;
    string problemType;
    string description;
    string client;
    string status;
    string master; //ответственный за работу

    public Order(int number, int day, int mouth, int year, string device, string problemType, string description, string client, string status, string master)
    {
        Number = number;
        Day = day;
        Mouth = mouth;
        Year = year;
        Device = device;
        ProblemType = problemType;
        Description = description;
        Client = client;
        Status = status;
        Master = master;
    }

    public int Number {get; set;}
    public int Day {get; set;}
    public int Mouth {get; set;}
    public int Year {get; set;}
    public string Device {get; set;}
    public string ProblemType {get; set;}
    public string Description {get; set;}
    public string Client {get; set;}
    public string Status {get; set;}
    public string Master { get; set; }
}