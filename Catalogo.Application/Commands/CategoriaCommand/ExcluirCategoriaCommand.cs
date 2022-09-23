using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Application.Commands.CategoriaCommand
{
    public class ExcluirCategoriaCommand : IRequest<Unit>
    {
        [FromRoute]
        public int Id { get; set; }

        //public ExcluirCategoriaCommand(int id)
        //{
        //    Id = id;
        //}
    }
}
