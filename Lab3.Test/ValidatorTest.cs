using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Test
{
    public class ValidatorTests
    {
        [Fact]
        public void TestValidateInput_ValidInput_DoesNotThrow()
        {
            string validInputPath = "valid_input.txt";
            File.WriteAllText(validInputPath, "3\n0 1 4\n1 0 2\n4 2 0");

            Validator.ValidateInput(validInputPath);
        }

        [Fact]
        public void TestValidateInput_EmptyFile_ThrowsException()
        {
            string emptyInputPath = "empty_input.txt";
            File.WriteAllText(emptyInputPath, "");

            Assert.Throws<InvalidOperationException>(() => Validator.ValidateInput(emptyInputPath));
        }

        [Fact]
        public void TestValidateInput_InvalidVertexCount_ThrowsException()
        {
            string invalidVertexCountPath = "invalid_vertex_count.txt";
            File.WriteAllText(invalidVertexCountPath, "101\n0 1 4");

            Assert.Throws<InvalidOperationException>(() => Validator.ValidateInput(invalidVertexCountPath));
        }

        [Fact]
        public void TestValidateInput_IncorrectWeightCount_ThrowsException()
        {
            string incorrectWeightCountPath = "incorrect_weight_count.txt";
            File.WriteAllText(incorrectWeightCountPath, "3\n0 1\n1 0 2\n4 2 0");

            Assert.Throws<InvalidOperationException>(() => Validator.ValidateInput(incorrectWeightCountPath));
        }

        [Fact]
        public void TestValidateInput_InvalidEdgeWeight_ThrowsException()
        {
            string invalidEdgeWeightPath = "invalid_edge_weight.txt";
            File.WriteAllText(invalidEdgeWeightPath, "3\n0 10001 4\n1 0 2\n4 2 0");

            Assert.Throws<InvalidOperationException>(() => Validator.ValidateInput(invalidEdgeWeightPath));
        }
    }
}
