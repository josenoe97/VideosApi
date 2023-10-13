
using VideosApi.Models;

namespace TestesVideoApi
{
    public class CategoriaTestes 
    {


        public CategoriaTestes()
        {
                
        }

        [Fact]
        public void TestandoAtribuicaoDeTituloCategoria()
        {
            //Arrange
            var categoria = new Categoria();

            //Act
            categoria.Titulo = "Cómedia";

            //Assert
            Assert.Equal("Cómedia", categoria.Titulo);
        }

        [Fact]
        public void TestandoAtribuicaoDeCorCategoria()
        {
            //Arrange
            var categoria = new Categoria();

            //Act
            categoria.Cor = "Verde";

            //Assert
            Assert.Equal("Verde", categoria.Cor);
        }
        
    }
}
