﻿namespace DataShark.DataGen.Models;

public class Project(Guid id, string name)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public List<Dataset> Datasets { get; set; } = [];
}