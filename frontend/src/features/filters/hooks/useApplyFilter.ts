import { useQueryClient } from '@tanstack/react-query';
import { useLocation, useNavigate } from 'react-router';
import { toQueryParams } from '../utils/toQueryParams';

export function useApplyFilter(category: string) {
  const queryClient = useQueryClient();
  const location = useLocation();
  const navigate = useNavigate();

  const applyFilter = (data: object) => {
    queryClient.invalidateQueries({ queryKey: ['products', category] });
    const qParams = toQueryParams(data);
    console.log(qParams);
    navigate(`${location.pathname}?${qParams}`, { replace: true });
  };

  return { applyFilter };
}
