using AutoMapper;
using DoubleVPartnersBI.BI;
using DoubleVPartnersRepository.ContextDB;
using DoubleVPartnersRepository.DTOs;
using DoubleVPartnersRepository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Se agrega la injeccion de dependencias de las interfaces de la capa de repositories
DoubleVPartnersRepository.Middleware.IoCRepositories.addDependency(builder.Services);
//// Se agrega la injeccion de dependencias de las interfaces de la capa de services
DoubleVPartnersBI.Middleware.IoCBI.addDependency(builder.Services);

var conection = builder.Configuration.GetConnectionString("Connectionkey");
builder.Services.AddDbContext<DoubleVPartnersDB>(options =>
{
    options.UseSqlServer(conection);
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        //policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    }
    );

});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);

#region Persona endpoints
var PersonaEndpointBase = "persona/v1/";
app.MapGet(PersonaEndpointBase, async (IPersonaBI personaBI, IMapper mapper) =>
 mapper.Map<List<PersonaDTO>>(await personaBI.getAll()));

app.MapGet(PersonaEndpointBase + "{Id}", async ([BindRequired] int Id, IPersonaBI personaBI, IMapper mapper) =>
 mapper.Map<PersonaDTO>(await personaBI.getById(Id)));

app.MapPost(PersonaEndpointBase, async ([FromBody] PersonaDTO persona, IPersonaBI personaBI, IMapper mapper) =>
 mapper.Map<PersonaDTO>(await personaBI.insert(mapper.Map<Persona>(persona))));

app.MapDelete(PersonaEndpointBase + "{Id}", async ([BindRequired] int Id, IPersonaBI personaBI, IMapper mapper) =>
 personaBI.delete(Id));
#endregion

#region Usuario Endpoints
var UserEndpointBase = "usuario/v1/";
app.MapGet(UserEndpointBase, async (IUsuariosBI usuarioBI, IMapper mapper) =>
 mapper.Map<List<UsuarioDTO>>(await usuarioBI.getAll()));

app.MapGet(UserEndpointBase + "{Id}", async ([BindRequired] int Id, IUsuariosBI usuarioBI, IMapper mapper) =>
 mapper.Map<UsuarioDTO>(await usuarioBI.getById(Id)));

app.MapPost(UserEndpointBase, async ([FromBody] UsuarioDTO usuario, IUsuariosBI usuarioBI, IMapper mapper) =>
 mapper.Map<UsuarioDTO>(await usuarioBI.insert(mapper.Map<Usuario>(usuario))));

app.MapDelete(UserEndpointBase + "{Id}", async ([BindRequired] int Id, IUsuariosBI usuarioBI, IMapper mapper) =>
 await usuarioBI.delete(Id));
#endregion


app.Run();
