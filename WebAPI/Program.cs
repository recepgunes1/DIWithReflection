using Business;
using Business.Services.Abstracts;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.LoadServicesManually();

// builder.Services.LoadServicesUsingReflection();

// builder.Services.LoadServicesUsingReflectionWithLifeTime();

builder.Services.LoadServicesUsingReflectionWithLifeTime_Strict();

var app = builder.Build();

app.MapGet("/api/Comment/LastComment", (ICommentService commentService) => commentService.GetLastComment());

app.MapGet("/api/Booking/CountBooking", (IBookingService bookingService) => bookingService.CountBooking());

app.MapGet("/api/User/UserName", (IUserService userService) => userService.GetUserName());

app.Run();