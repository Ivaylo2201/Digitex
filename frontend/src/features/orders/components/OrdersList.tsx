import { getStaticFile } from '@/lib/utils/getStaticFile';
import { useOrders } from '../hooks/useOrders';

export function OrdersList() {
  const { data } = useOrders();

  return (
    <div className='grid grid-cols-1 gap-6'>
      {data?.orders.map((order, orderIndex) => (
        <div
          key={orderIndex}
          className='border rounded-lg p-4 bg-white shadow-sm flex flex-col'
        >
          <div className='flex flex-col gap-4'>
            {order.items[0] && (
              <div className='flex gap-4 items-center'>
                <img
                  src={getStaticFile(order.items[0].product.imagePath)}
                  alt={order.items[0].product.modelName}
                  className='w-16 h-16 object-contain'
                />

                <div className='flex flex-col text-sm'>
                  <span className='font-semibold'>
                    {order.items[0].quantity}x{' '}
                    {order.items[0].product.brandName}{' '}
                    {order.items[0].product.modelName}
                  </span>
                  <span className='font-medium, text-gray-500'>
                    ${order.items[0].lineTotal}
                  </span>
                </div>
              </div>
            )}

            {order.items.length > 1 && (
              <details className='group border rounded-lg mt-2'>
                <summary className='cursor-pointer bg-gray-100 px-4 py-2 rounded-t-lg text-sm font-medium text-blue-600 flex justify-between items-center hover:bg-gray-200 transition'>
                  <span className='text-theme-gunmetal'>
                    View {order.items.length - 1} more item(s)
                  </span>
                  <span className='transition-transform group-open:rotate-180'>
                    ▼
                  </span>
                </summary>

                <div className='flex flex-col gap-3 pl-2 bg-white border-t'>
                  {order.items.slice(1).map((item) => (
                    <div
                      key={item.id}
                      className='flex gap-4 items-center rounded-lg p-3 transition'
                    >
                      <img
                        src={getStaticFile(item.product.imagePath)}
                        alt={item.product.modelName}
                        className='w-16 h-16 object-contain'
                      />

                      <div className='flex flex-col text-sm'>
                        <span className='font-semibold text-gray-800'>
                          {item.quantity}x {item.product.brandName}{' '}
                          {item.product.modelName}
                        </span>
                        <span className='text-gray-500 font-medium'>
                          ${item.lineTotal}
                        </span>
                      </div>
                    </div>
                  ))}
                </div>
              </details>
            )}
          </div>

          <div className='mt-4 flex flex-col border-t pt-3 text-sm gap-1'>
            <div className='text-gray-600'>
              <span className='font-medium text-theme-gunmetal'>
                Billing Address:
              </span>{' '}
              {order.billingAddress}
            </div>

            <div className='text-gray-600'>
              <span className='font-medium text-theme-gunmetal'>
                Shipment type:
              </span>{' '}
              {order.shipmentType}
            </div>

            <div className='flex justify-between font-semibold mt-2'>
              <span>Total: ${order.totalPrice}</span>
            </div>
          </div>
        </div>
      ))}
    </div>
  );
}
