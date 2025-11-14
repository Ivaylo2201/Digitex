import { useNavigate, useParams } from 'react-router';

type ProductParams = {
  category: string;
  id: string;
};

export const useProductParams = () => {
  const { category = '', id = '' } = useParams<ProductParams>();
  const navigate = useNavigate();

  if (category === undefined || id === undefined) {
    navigate('/404');
  }

  return { category, id };
};
