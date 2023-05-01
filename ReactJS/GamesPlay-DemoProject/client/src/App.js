import './App.css';
import { Routes, Route, useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';

import { Catalog } from './components/Catalog/Catalog';
import { CreateGame } from './components/CreateGame/CreateGame';
import { Header } from './components/Header/Header';
import { Home } from './components/Home/Home';
import { Login } from './components/Login/Login';
import { Register } from './components/Register/Register'

import { gameServiceFactory } from './services/gameService';
import { GameDetails } from './components/GameDetails/GameDetails';
import { userServiceFactory } from './services/userService';
import { UserContext } from './contexts/UserContext';
import { Logout } from './components/Logout/Logout';
import { useService } from './hooks/useService';


function App() {

  const navigate = useNavigate();

  const [games, setGames] = useState([]);
  const [user, setUser] = useState({});
  const gameService = gameServiceFactory(user.accessToken);
  const userService = userServiceFactory(user.accessToken);

  useEffect(() => {
    gameService.getAll().then(result => setGames(result));
  }, []);

  const onCreateGameSubmit = async (data) => {
    console.log(data);
    const newGame = await gameService.create(data);
    console.log(newGame);
    setGames(state => ([...state, newGame]));
    navigate('/catalog')
  }


  const onLoginSubmit = async (values) => {
    try {
      const userData = await userService.onLogin(values);
      setUser(userData);

      navigate('/catalog')
    } catch (error) {
      // TODO: handle login error
      console.log(error)
    }
  }

  const onRegisterSubmit = async (values) => {
    if (values.password !== values.confirmPassword) {
      // TOTO: handle not confirmed password
      console.log("Wrong confirm password");
      return;
    }

    const {confirmPassword, ...registerData} = values;

    try {
      const userData = await userService.onRegister(registerData);
      setUser(userData);

      navigate('/catalog')
    } catch (error) {
      // TODO: handle register error
      console.log(error)
    }
  }

  const onLogoutClick = () => {
    setUser({});
    userService.onLogout();
  }

  const userContext = {
    onLoginSubmit,
    onRegisterSubmit,
    onLogoutClick,
    userEmail: user.email,
    userId: user._id,
    token: user.accessToken,
    isLogged: !!user.accessToken,
  }


  return (
    <UserContext.Provider value = {userContext}>
    <div id="box">
      <Header />
      <main id="main-content">
        <Routes >
          <Route path='/' element={<Home />} />
          <Route path='/login' element={<Login />} />
          <Route path='/register' element={<Register />} />
          <Route path='/logout' element={<Logout />} />
          <Route path='/create-game' element={<CreateGame onCreateGameSubmit={onCreateGameSubmit} />} />
          <Route path='/catalog' element={<Catalog games={games} />} />
          <Route path='/:gameId' element={<GameDetails />} />

        </Routes>
      </main>
    </div>
    </UserContext.Provider>
  );
}

export default App;
