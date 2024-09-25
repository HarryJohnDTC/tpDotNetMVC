using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using dotNet.Models;

public class UserJSONRepository
{
    private string _filePath;

    public UserJSONRepository()
    {
        _filePath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "users.json");
    }

    public void SaveUser(Login user)
    {
        List<Login> users = GetUsers();

        users.Add(user); // Ajouter le nouvel utilisateur
        var json = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }

    public List<Login> GetUsers()
    {
        if (!File.Exists(_filePath))
            return new List<Login>(); // Retourner une liste vide si le fichier n'existe pas

        var json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<List<Login>>(json) ?? new List<Login>();
    }
}
