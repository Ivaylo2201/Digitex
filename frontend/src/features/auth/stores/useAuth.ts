import { create } from 'zustand';

type AuthStore = {
  role: string | null;
  token: string | null;
  isAuthenticated: boolean;
  signIn: (token: string, role: string, rememberMe?: boolean) => void;
  signOut: () => void;
};

const getToken = () => localStorage.getItem('token');

export const useAuthStore = create<AuthStore>((set) => ({
  role: localStorage.getItem('role'),
  token: getToken(),
  isAuthenticated: !!getToken(),

  signIn: (token, role) => {
    localStorage.setItem('token', token);
    localStorage.setItem('role', role);

    set({
      token,
      role,
      isAuthenticated: true,
    });
  },

  signOut: () => {
    localStorage.removeItem('token');
    localStorage.removeItem('role');

    set({
      token: null,
      role: null,
      isAuthenticated: false,
    });
  },
}));
