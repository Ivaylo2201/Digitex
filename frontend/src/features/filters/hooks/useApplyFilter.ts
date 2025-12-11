import { useQueryClient } from '@tanstack/react-query';
import { useLocation, useNavigate } from 'react-router';
import { toQueryParams } from '../utils/toQueryParams';

export function useApplyFilter(category: string) {
  const queryClient = useQueryClient();
  const location = useLocation();
  const navigate = useNavigate();

  const applyFilter = (data: object) => {
    queryClient.invalidateQueries({ queryKey: ['products', category] });
    navigate(`${location.pathname}?${toQueryParams(data)}`, { replace: true });
  };

  return { applyFilter };
}
