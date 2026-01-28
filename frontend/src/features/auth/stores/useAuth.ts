import { create } from 'zustand';

type AuthStore = {
  role: string | null;
  isAuthenticated: boolean;
  signIn: (token: string, role: string, rememberMe?: boolean) => void;
  signOut: () => void;
};

export const useAuthStore = create<AuthStore>((set) => ({
  role: null,
  isAuthenticated: !!localStorage.getItem('token'),
  signIn: (token: string, role: string, rememberMe: boolean = false) => {
    set({ isAuthenticated: true, role });
    
    if (['admin', 'manager'].includes(role.toLowerCase()))
      return; // Force admins to log in each time for security reasons

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
