using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Coding_Problems.Tests
{
    public class SnakesLaddersTests
    {
        private readonly SnakesLaddersSolver _sut;

        public SnakesLaddersTests()
        {
            _sut = new SnakesLaddersSolver();
        }

        [Fact]
        public void Sut_ShouldBeCreated() => _sut.Should().NotBeNull();


        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 0, 1, 2)]
        [InlineData(1, 0, 1, 2, 3)]
        [InlineData(1, 0, 1, 2, 3, 4)]
        [InlineData(1, 0, 1, 2, 3, 4, 5)]
        [InlineData(2, 0, 1, 2, 3, 4, 5, 6)]
        
        [InlineData(1, 0, 1, 2, 6, 4, 5, 6)]
        [InlineData(1, 0, 1, 7, 3, 4, 5, 3, 7)]
        [InlineData(2, 0, 1, 7, 3, 4, 5, 3, 7, 8, 9, 10, 11, 12)]
        [InlineData(3, 0, 1, 7, 3, 4, 5, 3, 7, 8, 9, 10, 11, 12, 13)]
        public void Sut_ShouldSolveBoards(int expected, params int[] board)
        {
            _sut.Solve(board)
                .Should().Be(expected);
        }

    }
}