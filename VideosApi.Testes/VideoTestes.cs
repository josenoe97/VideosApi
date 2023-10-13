using System.ComponentModel.DataAnnotations;
using VideosApi.Models;
using Xunit;

namespace VideosApi.Testes
{
    public class VideoTestes
    {
        [Fact]
        public void TestarNameTituloFilmeEmBranco()
        {
            //Arrange
            var video = new Video();

            //Act
            video.Titulo = "";

            //Assert
            Assert.(video.Titulo);
        }

    }
}