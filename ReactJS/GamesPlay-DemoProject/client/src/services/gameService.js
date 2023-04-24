import * as dataApi from './dataServerService';

const endponint = "/jsonstore/games"

export const getAllGames = async () => {
    const games = await dataApi.get(endponint);
    return Object.values(games);
}

export const createGame = async (data) => {
    const newGame = await dataApi.post(endponint, data);
    return newGame;
}

export const getOne = async (gameId) => {
    const result =  await dataApi.get(endponint + '/' + gameId);
    return result;
}