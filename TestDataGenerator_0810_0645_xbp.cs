// 代码生成时间: 2025-08-10 06:45:28
using System;
using System.Collections.Generic;
using System.Linq;

// TestDataGenerator.cs is a class to generate test data for MAUI applications.
public class TestDataGenerator
{
    // Generates a list of random names
    public List<string> GenerateRandomNames(int numberOfNames)
    {
        List<string> names = new List<string>();
        if (numberOfNames <= 0)
        {
            throw new ArgumentException("The number of names must be greater than zero.");
        }

        foreach (var _ in Enumerable.Range(1, numberOfNames))
        {
            string firstName = GetRandomNamePart();
            string lastName = GetRandomNamePart();
            names.Add($