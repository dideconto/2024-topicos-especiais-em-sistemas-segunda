import React from "react";
import ProdutoListar from "./components/pages/produto/produto-listar";
import ConsultarCep from "./components/pages/cep/consultar-cep";
import ProdutoCadastrar from "./components/pages/produto/produto-cadastrar";
import { BrowserRouter, Link, Route, Routes } from "react-router-dom";

function App() {
  return (
    <div>
      <BrowserRouter>
        <nav>
          <ul>
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/produto/listar">Listar Produtos</Link>
            </li>
            <li>
              <Link to="/produto/cadastrar">Cadastrar Produtos</Link>
            </li>
            <li>
              <Link to="/cep/consultar">Consultar CEP</Link>
            </li>
          </ul>
        </nav>
        <Routes>
          <Route path="/" element={<ProdutoListar />} />
          <Route path="/produto/listar" element={<ProdutoListar />} />
          <Route path="/produto/cadastrar" element={<ProdutoCadastrar />} />
          <Route path="/cep/consultar" element={<ConsultarCep />} />
        </Routes>
        <footer>
          <p>Desenvolvido por Diogo Steinke Deconto</p>
        </footer>
      </BrowserRouter>
    </div>
  );
}

export default App;
