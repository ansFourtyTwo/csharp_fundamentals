using System;
using Xunit;

namespace GradeBook.Test;

public class BookTests
{
    [Fact]
    public void BookCalculatesGradeStatistics()
    {
        // arrange
        var book = new InMemoryBook("");
        book.AddGrade(1.2);
        book.AddGrade(12.2);

        // act
        var stats = book.GetStatistics();

        // assert
        Assert.InRange<double>(6.7, 6.69, 6.71);
        Assert.Equal(1.2, stats.LowestGrade, 1);
        Assert.Equal(12.2, stats.HighestGrade, 1);
        Assert.Equal('F', stats.Letter);
    }

    [Fact]
    public void CanAddValidGrades()
    {
        var book = new InMemoryBook("Test Book");
        book.AddGrade(10.0);
        book.AddGrade(90.0);

        var stats = book.GetStatistics();
        Assert.Equal(10.0, stats.LowestGrade, 1);
        Assert.Equal(90.0, stats.HighestGrade, 1);
    }

    [Fact]
    public void CannotAddInvalidGrades()
    {
        var book = new InMemoryBook("Test Book");
        book.AddGrade(10.0);
        book.AddGrade(90.0);
        Assert.Throws<ArgumentException>(
            () => book.AddGrade(105.0)
        );

        var stats = book.GetStatistics();
        Assert.Equal(10.0, stats.LowestGrade, 1);
        Assert.Equal(90.0, stats.HighestGrade, 1);
    }


}