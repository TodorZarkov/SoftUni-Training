import { useContext } from "react";
import { GameInfo } from "./GameInfo";
import { GameContext } from "../../contexts/GameContext";

export const Catalog = () => {

    const {games} = useContext(GameContext);

    return (
        <section id="catalog-page">
            <h1>All Games</h1>
            {games.length !== 0 
                ?
                games.map(g => <GameInfo key={g.imageUrl} game={g} />)

                :
                <h3 className="no-articles">No articles yet</h3>
            }
        </section>
    );
};