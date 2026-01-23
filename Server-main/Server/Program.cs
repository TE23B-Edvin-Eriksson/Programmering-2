// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

// app.Run();

WebApplication app = WebApplication.Create(args);

List<Teacher> teachers = [
    new() {Name = "Gustav", Subject = "Idleon", Wage = 10},
    new() {Name = "Sandor", Subject = "surfa", Wage = 271},
    new() {Name = "Jeban", Subject = "rita", Wage = 100000},
];


app.MapGet("/", Hello);
app.MapGet("/Eddi", Eddi);
app.MapGet("/teachers", GiveTeacher);
app.MapGet("/teacher/{n}", GiveaTeacher);
app.MapPost("/teacher/new", AddTeacher);

app.Urls.Add("http://localhost:5044/");
app.Urls.Add("http://*:5044");

app.Run();

IResult AddTeacher(Teacher t)
{
    teachers.Add(t);

    return Results.Ok();
}

List<Teacher> GiveTeacher()
{
    
    return teachers;
}

IResult GiveaTeacher(int n)
{
    if (n < 0 || n >= teachers.Count)
    {
        return Results.NotFound();
    }

    
    return Results.Ok(teachers[n]);
}

static string Hello()
{
    return "Hello";
}

static string Eddi()
{
    return "my name is jeff";
}
