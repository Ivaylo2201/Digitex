type ManagerRequiredProps = React.PropsWithChildren;

export function ManagerRequired({ children }: ManagerRequiredProps) {
  //const isManager = useAuthStore((state) => state.role) === 'manager';
  //return isManager ? children : <Navigate to='/auth/sign-in' replace />;

  return children;
}
