type AdminRequiredProps = React.PropsWithChildren;

export function AdminRequired({ children }: AdminRequiredProps) {
  //const isAdmin = useAuthStore((state) => state.role) === 'admin';
  //return isAdmin ? children : <Navigate to='/auth/sign-in' replace />;

  return children;
}
