import { useEffect, useState } from "react";
import { Produto } from "../../../models/Produto";

//EXERCÍCIOS
//1 - Implementar o cadastro a partir do formulário
//2 - Implementar a remoção
//3 - Implementar a alteração

function ProdutoListar() {
  const [produtos, setProdutos] = useState<Produto[]>([]);
  //Evento de carregamento do componente
  useEffect(() => {
    console.log("Executar algo ao carregar o componente...");
    carregarProdutos();
  }, []);

  function carregarProdutos() {
    //FETCH ou AXIOS
    fetch("http://localhost:5076/api/produto/listar")
      .then((resposta) => resposta.json())
      .then((produtos: Produto[]) => {
        setProdutos(produtos);
        console.table(produtos);
      })
      .catch((erro) => {
        console.log("Deu erro!");
      });
  }

  return (
    <div>
      <h1>Listar Produtos</h1>
      <table>
        <thead>
          <tr>
            <th>#</th>
            <th>Nome</th>
            <th>Desrição</th>
            <th>Preço</th>
            <th>Quantidade</th>
            <th>Criado Em</th>
          </tr>
        </thead>
        <tbody>
          {produtos.map((produto) => (
            <tr key={produto.id}>
              <td>{produto.id}</td>
              <td>{produto.nome}</td>
              <td>{produto.descricao}</td>
              <td>{produto.preco}</td>
              <td>{produto.quantidade}</td>
              <td>{produto.criadoEm}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ProdutoListar;
