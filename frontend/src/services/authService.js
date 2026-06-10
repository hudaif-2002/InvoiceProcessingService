import axios from "axios";
const API_URL =
    `${import.meta.env.VITE_API_BASE_URL}/auth`;

const register = async (userData) => {
    return await axios.post(API_URL + "register", userData);
};

const login = async (userData) => {
    const response = await axios.post(API_URL + "login", userData);


    if (response.data.token)
        localStorage.setItem("token", response.data.token);

    return response.data;
};

const logout = () => {
    localStorage.removeItem("token");
};

const authService = {
    register, login, logout
};
export default authService;