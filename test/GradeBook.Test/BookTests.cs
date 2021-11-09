using System;
using Xunit;

namespace GradeBook.Test;

public class BookTests
{
    [Fact]
    public void BookCalculatesGradeStatistics()
    {
        // arrange
        var book = new Book("");
        book.AddGrade(1.2);
        book.AddGrade(12.2);

        // act
        var stats = book.GetStatistics();

        // assert
        Assert.InRange<double>(6.7, 6.69, 6.71);
        Assert.Equal(1.2, stats.LowestGrade, 1);
        Assert.Equal(12.2, stats.HighestGrade, 1);
    }
}