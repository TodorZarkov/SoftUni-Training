import './App.css';
import Header from './components/Header';
import Users from './components/Users';
import Details from './components/Details';
import CreateEdit from './components/CreateEdit';
import Delete from './components/Delete';
import Footer from './components/Footer';

function App() {
  return (
    <>
      <Header />

      <main class="main">
        <Users />

        {/* <Details /> */}

        {/* <CreateEdit /> */}

        {/* <Delete /> */}

      </main>

      <Footer />
    </>
  );
}

export default App;
