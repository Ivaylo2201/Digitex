import {
  Pagination,
  PaginationContent,
  PaginationItem,
  PaginationPrevious,
  PaginationLink,
  PaginationEllipsis,
  PaginationNext,
} from '@/components/ui/pagination';
import { useTranslation } from '@/features/language/hooks/useTranslation';

type ProductsPaginationProps = {
  page: number;
  setPage: React.Dispatch<React.SetStateAction<number>>;
  totalPages: number;
  pageSize: number;
};

export function ProductsPagination({
  page,
  setPage,
  totalPages,
}: ProductsPaginationProps) {
  const {
    components: { productsPagination },
  } = useTranslation();
  const start = Math.max(1, page - 1);
  const end = Math.min(totalPages, page + 1);

  return (
    <div className='flex flex-col items-center gap-5'>
      <Pagination>
        <PaginationContent>
          <PaginationItem>
            <PaginationPrevious
              previousText={productsPagination.previous}
              onClick={() => setPage((p) => Math.max(1, p - 1))}
              className='cursor-pointer'
            />
          </PaginationItem>

          {start > 1 && (
            <PaginationItem>
              <PaginationLink
                className='cursor-pointer'
                onClick={() => setPage(1)}
              >
                1
              </PaginationLink>
            </PaginationItem>
          )}

          {start > 2 && (
            <PaginationItem>
              <PaginationEllipsis />
            </PaginationItem>
          )}

          {Array.from({ length: end - start + 1 }, (_, i) => start + i).map(
            (p) => (
              <PaginationItem key={p}>
                <PaginationLink
                  isActive={p === page}
                  onClick={() => setPage(p)}
                  className={
                    p === page
                      ? 'bg-theme-gunmetal border-0 text-white pointer-events-none'
                      : 'cursor-pointer'
                  }
                >
                  {p}
                </PaginationLink>
              </PaginationItem>
            )
          )}

          {end < totalPages - 1 && (
            <PaginationItem>
              <PaginationEllipsis />
            </PaginationItem>
          )}

          {end < totalPages && (
            <PaginationItem>
              <PaginationLink
                className='cursor-pointer'
                onClick={() => setPage(totalPages)}
              >
                {totalPages}
              </PaginationLink>
            </PaginationItem>
          )}

          <PaginationItem>
            <PaginationNext
              nextText={productsPagination.next}
              onClick={() => setPage((p) => Math.min(totalPages, p + 1))}
              className='cursor-pointer'
            />
          </PaginationItem>
        </PaginationContent>
      </Pagination>
    </div>
  );
}
