import { useContext } from "react";
import { Link } from "react-router-dom";
import { UserContext } from "../../contexts/UserContext";

export const Header = () => {
    const { isLogged } = useContext(UserContext);
    return (
        <header>
            {/* <!-- Navigation --> */}
            <h1><Link className="home" to=''>GamesPlay</Link></h1>
            <nav>
                <Link to='/catalog'>All games</Link>
                {isLogged && (
                    <div id="user">
                        <Link to='/create-game'>Create Game</Link>
                        <Link to=''>Logout</Link>
                    </div>
                )}

                {!isLogged && (
                    <div id="guest">
                        <Link to='/login'>Login</Link>
                        <Link to='/register'>Register</Link>
                    </div>
                )}

            </nav>
        </header>
    );
};