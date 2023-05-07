// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Ecom
{
	/// <summary>
	/// Output parameters for the <see cref="EcomInterface.Checkout" /> Function.
	/// </summary>
	public class CheckoutCallbackInfo : ICallbackInfo, ISettable
	{
		/// <summary>
		/// Result code for the operation. <see cref="Result.Success" /> is returned for a successful request, otherwise one of the error codes is returned. See eos_common.h
		/// </summary>
		public Result ResultCode { get; private set; }

		/// <summary>
		/// Context that was passed into <see cref="EcomInterface.Checkout" />
		/// </summary>
		public object ClientData { get; private set; }

		/// <summary>
		/// The Epic Online Services Account ID of the user who initiated the purchase
		/// </summary>
		public EpicAccountId LocalUserId { get; private set; }

		/// <summary>
		/// The transaction ID which can be used to obtain an <see cref="Transaction" /> using <see cref="EcomInterface.CopyTransactionById" />.
		/// </summary>
		public string TransactionId { get; private set; }

		public Result? GetResultCode()
		{
			return ResultCode;
		}

		internal void Set(CheckoutCallbackInfoInternal? other)
		{
			if (other != null)
			{
				ResultCode = other.Value.ResultCode;
				ClientData = other.Value.ClientData;
				LocalUserId = other.Value.LocalUserId;
				TransactionId = other.Value.TransactionId;
			}
		}

		public void Set(object other)
		{
			Set(other as CheckoutCallbackInfoInternal?);
		}
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct CheckoutCallbackInfoInternal : ICallbackInfoInternal
	{
		private Result m_ResultCode;
		private System.IntPtr m_ClientData;
		private System.IntPtr m_LocalUserId;
		private System.IntPtr m_TransactionId;

		public Result ResultCode
		{
			get
			{
				return m_ResultCode;
			}
		}

		public object ClientData
		{
			get
			{
				object value;
				Helper.TryMarshalGet(m_ClientData, out value);
				return value;
			}
		}

		public System.IntPtr ClientDataAddress
		{
			get
			{
				return m_ClientData;
			}
		}

		public EpicAccountId LocalUserId
		{
			get
			{
				EpicAccountId value;
				Helper.TryMarshalGet(m_LocalUserId, out value);
				return value;
			}
		}

		public string TransactionId
		{
			get
			{
				string value;
				Helper.TryMarshalGet(m_TransactionId, out value);
				return value;
			}
		}
	}
}