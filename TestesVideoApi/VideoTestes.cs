using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using VideosApi.Models;

namespace TestesVideoApi
{
    public class VideoTestes 
    {
        

        [Fact]
        public void TestandoAtribuicaoDeTituloEmVideo()
        {
            //Arrange
            var video = new Video();

            //Act
            video.Titulo = "Educação";

            //Assert
            Assert.Equal("Educação", video.Titulo);
        }

        [Fact]
        public void TestandoAtribuicaoDeDescricaoEmVideo()
        {
            //Arrange
            var video = new Video();

            //Act
            video.Descricao = "Video de como ensinar c# do básico ao avançado";

            //Assert
            Assert.Equal("Video de como ensinar c# do básico ao avançado", video.Descricao);
        }

        [Fact]
        public void TestandoAtribuicaoDeUrlEmVideo()
        {
            var video = new Video();

            //Act
            video.Url = "https://github.com/josenoe97/treinamento_xUnit/blob/main/Estacionamento.Testes/VeiculoTestes.cs";

            //Assert
            Assert.Equal("https://github.com/josenoe97/treinamento_xUnit/blob/main/Estacionamento.Testes/VeiculoTestes.cs", video.Url);
        }

        [Fact]
        public void TestIdEhChavePrimaria()
        {
            // Arrange
            var video = new Video();

            // Act
            var propriedadeId = video.GetType().GetProperty("Id");

            // Assert
            Assert.NotNull(propriedadeId);
            Assert.True(propriedadeId.IsDefined(typeof(KeyAttribute), false));
        }

        [Fact]
        public void TestDescricaoObrigatorio()
        {
            // Arrange
            var video = new Video { Descricao = null };

            // Act
            var context = new ValidationContext(video, null, null);
            var resultados = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(video, context, resultados, true);

            // Assert
            Assert.False(isValid);
            var mensagemErro = Assert.Single(resultados);
            Assert.Equal("Nome deve ter entre 10 e 100 caracteres!", mensagemErro.ErrorMessage);
        }

    }
}