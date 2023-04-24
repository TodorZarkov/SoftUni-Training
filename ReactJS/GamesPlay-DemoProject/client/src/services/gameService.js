import * as dataApi from './dataServerService';

const endponint = "/jsonstore/games"

export const getAllGames = async () => {
    const games = await dataApi.get(endponint);
    return games;
}