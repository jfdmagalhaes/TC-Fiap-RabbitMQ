using NotificationAPI;

await Host
    .CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(builder =>
    {
        builder.UseStartup<Startup>();


        builder.ConfigureAppConfiguration(configBuilder =>
        {
            var configuration = configBuilder.Build();
        });
    })
    .Build()
    .RunAsync();