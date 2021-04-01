using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            //Atualiza lista com novo objeto(entidade). O id é a posicao a ser atualizada e a entidade o obejeto
            listaSerie[id] = entidade;
        }

        public void Exclui(int id) //metodo para tornar true como excluido, mas nao exclui do vetor. Apenas muda a chave
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie entidade) //metodo para add novo objeto a lista
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista() //metodo para listar a lista
        {
            return listaSerie;
        }

        public int ProximoId() //metodo para dizer quantos itens tem na lista
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id) //retorna objeto especifico conforme id passado como argumento
        {
            return listaSerie[id];
        }
    }
}
