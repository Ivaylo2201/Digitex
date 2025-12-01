import { create } from 'zustand';

type AuthStore = {
  role: string | null;
  isAuthenticated: boolean;
  signIn: (token: string, role: string, rememberMe: boolean) => void;
  signOut: () => void;
};

export const useAuth = create<AuthStore>((set) => ({
  role: null,
  isAuthenticated: !!localStorage.getItem('token'),
  signIn: (token: string, role: string, rememberMe: boolean) => {
    set({ isAuthenticated: true, role });

    if (rememberMe) {
      localStorage.setItem('token', token);
      sessionStorage.removeItem('token');
    } else {
      localStorage.removeItem('token');
      sessionStorage.setItem('token', token);
    }
  },
  signOut: () => {
    set({ isAuthenticated: false, role: null });
    localStorage.removeItem('token');
    sessionStorage.removeItem('token');
  },
}));
