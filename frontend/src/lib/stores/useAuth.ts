import { create } from "zustand";

type AuthStore = {
  isAuthenticated: boolean;
  signIn: (token: string, rememberMe: boolean) => void;
  signOut: () => void;
};

export const useAuth = create<AuthStore>((set) => ({
  isAuthenticated: !!localStorage.getItem('token'),
  signIn: (token: string, rememberMe: boolean) => {
    set({ isAuthenticated: true });

    if (rememberMe) {
      localStorage.setItem('token', token);
      sessionStorage.removeItem('token');
    } else {
      localStorage.removeItem('token');
      sessionStorage.setItem('token', token);
    }
  },
  signOut: () => {
    set({ isAuthenticated: false });
    localStorage.removeItem('token');
    sessionStorage.removeItem('token');
  }
}));