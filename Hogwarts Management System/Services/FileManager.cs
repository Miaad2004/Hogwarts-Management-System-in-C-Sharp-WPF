using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Hogwarts_Management_System.Models;
using Newtonsoft.Json;

public static class FileManager
{
    private static string SavePath = Globals.SavePath;

    public static void Save()
    {
        SaveList(Path.Combine(SavePath, "Students.json"), Globals.Students);
        SaveList(Path.Combine(SavePath, "Teachers.json"), Globals.Teachers);
        SaveList(Path.Combine(SavePath, "Admins.json"), Globals.Admins);
        SaveList(Path.Combine(SavePath, "ChatMessages.json"), Globals.ChatMessages);
        SaveList(Path.Combine(SavePath, "Assignments.json"), Globals.Assignments);
        //SaveList(Path.Combine(SavePath, "ActivationCodes.json"), Globals.ActivationCodes);
    }

    private static void SaveList<T>(string path, List<T> list)
    {
        try
        {
            var json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, json);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to save {path}.", ex);
        }
    }

    public static void Load()
    {
        Globals.Students = LoadList<Student>(Path.Combine(SavePath, "Students.json"));
        Globals.Teachers = LoadList<Teacher>(Path.Combine(SavePath, "Teachers.json"));
        Globals.Admins = LoadList<Admin>(Path.Combine(SavePath, "Admins.json"));
        Globals.ChatMessages = LoadList<ChatMessage>(Path.Combine(SavePath, "ChatMessages.json"));
        Globals.Assignments = LoadList<Assignment>(Path.Combine(SavePath, "Assignments.json"));
        Globals.ActivationCodes = LoadList<ActivationCode>(Path.Combine(SavePath, "ActivationCodes.json"));
    }

    private static List<T> LoadList<T>(string path)
    {
        if (!File.Exists(path))
        {
            var emptyList = new List<T>();
            var json = JsonConvert.SerializeObject(emptyList);
            File.WriteAllText(path, json);
            return emptyList;
        }

        try
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

}
