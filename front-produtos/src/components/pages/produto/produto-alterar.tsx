import { useEffect, useState } from "react";
import { Produto } from "../../../models/Produto";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";

function ProdutoAlterar() {
  const navigate = useNavigate();
  const { id } = useParams<{ id: string }>();
  const [nome, setNome] = useState("");
  const [descricao, setDescricao] = useState("");
  const [preco, setPreco] = useState("");
  const [quantidade, setQuantidade] = useState("");

  useEffect(() => {
    if (id) {
      axios
        .get<Produto>(
          `http://localhost:5076/api/produto/buscar/${id}`
        )
        .then((resposta) => {
          setNome(resposta.data.nome);
          setDescricao(resposta.data.descricao);
          setPreco(resposta.data.preco.toString());
          setQuantidade(resposta.data.quantidade.toString());
        });
    }
  }, []);

  function salvar(e: any) {
    e.preventDefault();
    const produto: Produto = {
      nome: nome,
      descricao: descricao,
      preco: parseFloat(preco),
      quantidade: parseInt(quantidade),
    };
    axios
      .put<Produto>(
        `http://localhost:5076/api/produto/alterar/${id}`,
        produto
      )
      .then((produtoAlterado) => {
        navigate("/produto/listar");
      });
  }

  return (
    <div>
      <h1>Alterar Produto</h1>
      <form onSubmit={salvar}>
        <label>Nome:</label>
        <input
          type="text"
          value={nome}
          onChange={(e: any) => setNome(e.target.value)}
          required
        />{" "}
        <br />
        <label>Descrição:</label>
        <input
          type="text"
          value={descricao}
          onChange={(e: any) => setDescricao(e.target.value)}
        />{" "}
        <br />
        <label>Preço:</label>
        <input
          type="text"
          value={preco}
          onChange={(e: any) => setPreco(e.target.value)}
        />{" "}
        <br />
        <label>Quantidade:</label>
        <input
          type="text"
          value={quantidade}
          onChange={(e: any) => setQuantidade(e.target.value)}
        />{" "}
        <br />
        <button type="submit">Salvar</button>
      </form>
    </div>
  );
}

export default ProdutoAlterar;
